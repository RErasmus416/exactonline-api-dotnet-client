﻿using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetSpecificCollectionCusingOData184244
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task GetSpecificCollectionUsingOData()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		var accounts = client.For<GLAccount>()
			.Select("Code")
			.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
			.And($"Code+eq+'{TestObjectsCreator.SpecificGLAccountCode}'")
			.Get();

		Assert.IsTrue(accounts.Any());
	}
}
