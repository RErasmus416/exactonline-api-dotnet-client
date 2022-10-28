﻿using ExactOnline.Client.Models.Financial;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class ModificationRestrictions
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task ModificationRestrictions_Succeed()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		// Create
		var newJournal = new Journal { Description = "New Journal" };
		try { client.For<Journal>().Insert(ref newJournal); throw new Exception(); } catch { }

		// Update
		var journal = client.For<Journal>().Top(1).Select("ID").Get().First();
		journal.Description = "Test Description";
		try { client.For<Journal>().Update(journal); throw new Exception(); } catch { }

		// Delete
		try { client.For<Journal>().Delete(journal); throw new Exception(); } catch { }
	}
}
