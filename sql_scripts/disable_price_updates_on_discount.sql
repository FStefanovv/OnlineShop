CREATE OR REPLACE FUNCTION check_if_product_is_on_discount()
    RETURNS TRIGGER AS
$$
BEGIN
    IF EXISTS (
        SELECT 1 FROM "Discounts"
        WHERE "ProductId" = NEW."Id" AND "ValidUntil" > CURRENT_TIMESTAMP
    ) THEN
        RAISE EXCEPTION 'The product is on discount, cannot change price until it expires';
    ELSE 
        RETURN NEW;
    END IF;

END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER disable_price_updates
BEFORE UPDATE OF "Price" ON "Products" 
FOR EACH ROW
EXECUTE FUNCTION check_if_product_is_on_discount();