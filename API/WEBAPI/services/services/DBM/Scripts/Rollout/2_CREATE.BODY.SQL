CREATE TABLE BODY(
                       ID INTEGER PRIMARY KEY AUTOINCREMENT,
                       BODY_NAME TEXT NOT NULL                   
);
CREATE INDEX idx_body ON BODY(ID);