use gtn

select * from persons order by personID
select * from persontypes

SET IDENTITY_INSERT persons ON;
GO
INSERT INTO persons (personID, FullName, Phone, Email, Location, Notes, orgID, personTypeID)
VALUES ( 2, '[Not Set]', NULL, NULL, NULL, NULL, NULL,  2);

INSERT INTO persons (personID, FullName, Phone, Email, Location, Notes, orgID, personTypeID)
VALUES ( 3, '[Not Set]', NULL, NULL, NULL, NULL, NULL,  4);

INSERT INTO persons (personID, FullName, Phone, Email, Location, Notes, orgID, personTypeID)
VALUES ( 5, '[Not Set]', NULL, NULL, NULL, NULL, NULL,  5);

INSERT INTO persons (personID, FullName, Phone, Email, Location, Notes, orgID, personTypeID)
VALUES ( 6, '[Not Set]', NULL, NULL, NULL, NULL, NULL,  6);
GO

SET IDENTITY_INSERT persons OFF;
GO

select * from PersonTypes