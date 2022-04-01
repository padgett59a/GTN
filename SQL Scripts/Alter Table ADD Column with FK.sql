use gtn
ALTER TABLE Persons
    ADD PersonTypeID INTEGER,
    FOREIGN KEY(PersonTypeID) REFERENCES PersonTypes(PersonTypeID);