CREATE TABLE BODY_ITEM(
                          ID INTEGER PRIMARY KEY AUTOINCREMENT,
                          BODY_ID INTEGER,
                          BODY_ITEM_NAME TEXT NOT NULL,
                          FOREIGN KEY (BODY_ID) REFERENCES BODY(ID)
);

CREATE INDEX idx_body_item_name ON BODY_ITEM(BODY_ITEM_NAME);