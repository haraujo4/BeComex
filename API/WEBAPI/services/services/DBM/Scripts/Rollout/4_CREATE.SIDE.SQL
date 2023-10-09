CREATE TABLE SIDE(
                     ID INTEGER PRIMARY KEY AUTOINCREMENT,
                     ID_BODY_ITEM INTEGER,
                     SIDE TEXT NOT NULL,
                     FOREIGN KEY (ID_BODY_ITEM) REFERENCES BODY_ITEM(ID)
);

CREATE INDEX idx_side_name ON SIDE(SIDE);
