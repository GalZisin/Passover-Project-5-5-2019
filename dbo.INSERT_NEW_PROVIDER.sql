﻿CREATE PROCEDURE INSERT_NEW_PROVIDER
@USERNAME varchar(50),
@PASS int,
@COMPANY_NAME varchar(50)
AS
INSERT INTO Providers(USERNAME, PASS, COMPANY_NAME) values(@USERNAME, @PASS, @COMPANY_NAME);