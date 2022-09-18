﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExactOnline.Client.Sdk.Sync
{
	public static class ExactOnlineSynchronizer
	{
		private static readonly Lazy<List<Type>> _supportedModelTypes = new(() =>
				new Services().ServicesDictionary
					.Keys
					.Select(typeName => Type.GetType(typeName + ",ExactOnline.Client.Models"))
					.Where(type => SupportsModelType(type))
					.ToList());

		public static List<Type> SupportedModelTypes => _supportedModelTypes.Value;

		private static bool SupportsModelType(Type type)
		{
			var modelInfo = ModelInfo.For(type);
			return (modelInfo.SupportsRead || modelInfo.SupportsBulk || modelInfo.SupportsSync) &&
				modelInfo.IdentifierName != null && // We only support entities that have an identifier
				type != typeof(Client.Models.Logistics.StockPosition); // StockPosition is a function
		}
	}
}
