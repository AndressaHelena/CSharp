﻿use FiapSmartCity;

ALTER TABLE CADASTRO

ADD CONSTRAINT [FK_IDPET] FOREIGN KEY ([IDPET]) REFERENCES [dbo].[PET] ([IDPET]);

