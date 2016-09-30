﻿using System;
using Nest;

namespace Tests.Mapping.Types.Core.Boolean
{
	public class BooleanTest
	{
		[Boolean(
			DocValues = false,
			Similarity = "BM25",
			Index = false,
			Store = true)]
		public bool Full { get; set; }

		[Boolean]
		public bool Minimal { get; set; }
	}

	public class BooleanMappingTests : TypeMappingTestBase<BooleanTest>
	{
		protected override object ExpectJson => new
		{
			properties = new
			{
				full = new
				{
					type = "boolean",
					doc_values = false,
					similarity = "BM25",
					store = true,
					index = false,
				},
				minimal = new
				{
					type = "boolean"
				}
			}
		};

		protected override Func<PropertiesDescriptor<BooleanTest>, IPromise<IProperties>> FluentProperties => p => p
			.Boolean(s => s
				.Name(o => o.Full)
				.DocValues(false)
				.Similarity(SimilarityOption.BM25)
				.Index(false)
				.Store(true)
			)
			.Boolean(s => s
				.Name(o => o.Minimal)
			);
	}
}
