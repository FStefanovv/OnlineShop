CREATE OR REPLACE FUNCTION check_bank_account_ownership()
    RETURNS TRIGGER AS
$$
BEGIN
    IF NEW."CompanyId" IS NULL AND NEW."UserId" IS NULL THEN
        RAISE EXCEPTION 'A bank account must have an owner of type company or personal';
    END IF;
    RETURN NEW;
END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER validate_ownership
BEFORE INSERT ON "BankAccounts"
FOR EACH ROW
EXECUTE FUNCTION check_bank_account_ownership();