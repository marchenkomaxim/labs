using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.PasswordHashingUtils;

namespace Lab_2
{
	public class Testing
	{
		private const string cyrilicString = "Кирилиця";
		private const string latinString = "Latin";
		private const string hieroglyphsString = "𐤀𐤁‎𐤂‎𐤃‎𓃾𓉐𓌙𓇯";
		private const string emojisString = "🧪🧐🚩🥅💫🔍";
		private const string emptyString = "";
		private const string nullString = null;
		private const string spaceString = " ";

		[TestClass]
		public class Init
		{
			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(nullString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsUintMin_Init(string salt)
			{
				try
				{
					PasswordHasher.Init(salt, uint.MinValue);
					Assert.IsTrue(true, "Should be true");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(nullString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsUintMinBonusOne_Init(string salt)
			{
				try
				{
					PasswordHasher.Init(salt, uint.MinValue + 1);
					Assert.IsTrue(true, "Should be true");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(nullString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsUintMax_Init(string salt)
			{
				try
				{
					PasswordHasher.Init(salt, uint.MaxValue);
					Assert.IsTrue(true, "Should be true");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(nullString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsUintMaxMinusOne_Init(string salt)
			{
				try
				{
					PasswordHasher.Init(salt, uint.MaxValue - 1);
					Assert.IsTrue(true, "Should be true");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}
		}

		[TestClass]
		public class GetHash
		{
			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMin_NotNull_GetHash(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MinValue);
					string pass = PasswordHasher.GetHash(saltAndHash);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMinBonusOne_NotNull_GetHash(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MinValue + 1);
					string pass = PasswordHasher.GetHash(saltAndHash);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMax_NotNull_GetHash(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MaxValue);
					string pass = PasswordHasher.GetHash(saltAndHash);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMaxMinusOne_NotNull_GetHash(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MaxValue - 1);
					string pass = PasswordHasher.GetHash(saltAndHash);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(uint.MinValue)]
			[DataRow(uint.MinValue + 1)]
			[DataRow(uint.MaxValue)]
			[DataRow(uint.MaxValue - 1)]
			public void TestNullPasswordDifferentUint_Null_GetHash(uint adler)
			{
				try
				{
					PasswordHasher.Init(nullString, adler);
					string pass = PasswordHasher.GetHash(nullString);
					Assert.IsNull(pass, "Password should be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMin_NotNull_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMinBonusOne_NotNull_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue + 1);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMax_NotNull_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentPasswordsUintMaxMinusOne_NotNull_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue - 1);
					Assert.IsNotNull(pass, "Password can't be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(uint.MinValue)]
			[DataRow(uint.MinValue + 1)]
			[DataRow(uint.MaxValue)]
			[DataRow(uint.MaxValue - 1)]
			public void TestNullPasswordDifferentUint_Null_GetHashWithAllParametrs
				(uint adler)
			{
				try
				{
					string pass = PasswordHasher.GetHash(nullString, nullString, adler);
					Assert.IsNull(pass, "Password should be null!");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMin_AreEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MinValue);

					string pass1 = PasswordHasher.GetHash(saltAndHash);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMinBonusOne_AreEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MinValue + 1);

					string pass1 = PasswordHasher.GetHash(saltAndHash);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMax_AreEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MaxValue);

					string pass1 = PasswordHasher.GetHash(saltAndHash);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMaxMinusOne_AreEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					PasswordHasher.Init(saltAndHash, uint.MaxValue - 1);

					string pass1 = PasswordHasher.GetHash(saltAndHash);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMin_AreEqual_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue);
					string pass2 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMinBonusOne_AreEqual_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue + 1);
					string pass2 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MinValue + 1);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMax_AreEqual_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue);
					string pass2 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(emptyString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMaxMinusOne_AreEqual_GetHashWithAllParametrs
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue - 1);
					string pass2 = PasswordHasher.GetHash(saltAndHash,
						saltAndHash, uint.MaxValue - 1);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreEqual(pass1, pass2, "Passwords should be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMin_AreNotEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash);
					PasswordHasher.Init(saltAndHash, uint.MinValue);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreNotEqual(pass1, pass2, "Passwords shouldn't be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMinBonusOne_AreNotEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash);
					PasswordHasher.Init(saltAndHash, uint.MinValue + 1);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreNotEqual(pass1, pass2, "Passwords shouldn't be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMax_AreNotEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash);
					PasswordHasher.Init(saltAndHash, uint.MaxValue);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreNotEqual(pass1, pass2, "Passwords shouldn't be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}

			[DataTestMethod]
			[DataRow(cyrilicString)]
			[DataRow(latinString)]
			[DataRow(hieroglyphsString)]
			[DataRow(emojisString)]
			[DataRow(spaceString)]
			public void TestDifferentSaltsAndPasswordsUintMaxMinusOne_AreNotEqual_GetHash
				(string saltAndHash)
			{
				try
				{
					string pass1 = PasswordHasher.GetHash(saltAndHash);
					PasswordHasher.Init(saltAndHash, uint.MaxValue - 1);
					string pass2 = PasswordHasher.GetHash(saltAndHash);

					Assert.IsNotNull(pass1, "Password1 can't be null!");
					Assert.IsNotNull(pass2, "Password2 can't be null!");
					Assert.AreNotEqual(pass1, pass2, "Passwords shouldn't be equal");
				}
				catch (Exception exception)
				{
					Assert.Fail(exception.Message, "There should be no exception");
				}
			}
		}
	}
}
