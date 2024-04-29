CREATE OR REPLACE FUNCTION check_existing_discounts()
    RETURNS TRIGGER AS
$$
BEGIN
    IF EXISTS (
        SELECT 1 FROM "Discounts" 
        WHERE "ProductId" = NEW."ProductId" AND "ValidUntil" > CURRENT_TIMESTAMP
    ) THEN
        RAISE EXCEPTION 'There is an active discount on this product, cannot add another one';
    ELSE 
        RETURN NEW;
    END IF;
END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER prevent_duplicate_discount
BEFORE INSERT ON "Discounts"
FOR EACH ROW
EXECUTE FUNCTION check_existing_discounts();
