CREATE PROC contactField
@FullName NVARCHAR(256),
@EmailAddress NVARCHAR(255),
@MessageSubject NVARCHAR(MAX),
@SendMessages NVARCHAR(MAX)
AS
BEGIN
INSERT INTO dbo.Send_Contact
(
FullName,
EmailAddress,
MessageSubject,
SendMessages
)
VALUES
(
@FullName,
@EmailAddress,
@MessageSubject,
@SendMessages
)
END

SELECT * FROM dbo.Send_Contact 