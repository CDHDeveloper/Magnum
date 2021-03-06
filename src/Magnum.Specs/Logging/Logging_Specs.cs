// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Specs.Logging
{
	using System;
	using Magnum.Logging;
	using NUnit.Framework;

	[TestFixture]
	public class Using_an_expression_based_logger
	{
		static readonly ILogger _log = Logger.GetLogger<Using_an_expression_based_logger>();

		[Test]
		public void Should_allow_me_to_provide_enough_information_for_logging()
		{
			string name = "Chris";

			try
			{
				throw new InvalidOperationException("Boom!");
			}
			catch (Exception ex)
			{
				_log.Error(ex);
			}
		}

		[Test]
		public void Should_work_with_lambda_methods()
		{
			_log.Error(x => x.Write("Hello {0}", "Chris"));
		}

		[Test]
		public void Should_not_output_debug_if_not_configured()
		{
			_log.Debug("This should not be visible");
		}
	}
}