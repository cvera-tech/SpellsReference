/* 
	This transaction deletes all the rows from the database.
	Note that since it's using DELETE rather than TRUNCATE,
	the transaction will run very slowly for large tables.
	In order to use TRUNCATE, the foreign key constraints on
	SpellbookSpells would have to be removed and readded.

	Only use this transaction for development purposes!
*/
BEGIN TRANSACTION [ResetDatabase]
	BEGIN TRY
		DELETE FROM [SpellsReferenceCore].[dbo].[SpellbookSpells]
		DELETE FROM [SpellsReferenceCore].[dbo].[Spellbooks]
		DBCC CHECKIDENT ('[SpellsReferenceCore].[dbo].[Spellbooks]',RESEED, 0)
		DELETE FROM [SpellsReferenceCore].[dbo].[Spells]
		DBCC CHECKIDENT ('[SpellsReferenceCore].[dbo].[Spells]', RESEED, 0)
		COMMIT TRANSACTION [ResetDatabase]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [ResetDatabase]
	END CATCH