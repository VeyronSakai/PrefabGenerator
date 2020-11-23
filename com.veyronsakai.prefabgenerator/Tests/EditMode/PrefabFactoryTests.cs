using System;
using NUnit.Framework;
using PrefabGenerator;
using UnityEditor;
using UnityEngine;

namespace Tests.EditMode
{
    public sealed class PrefabFactoryTests
    {
        private const string MockObjName = "MockPrefab";
        private const string MockObjRelPath = "MockPrefab";
        private const string MockObjAbsPath = "Assets/Resources/" + MockObjName + ".prefab";
        private const string NeverUsedPrefabPath = "__NeverUsedPrefab__";

        private PrefabFactory _factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            // Resourcesフォルダを作成する。もし既にあるなら作らない。
            
            var obj = new GameObject
            {
                name = MockObjName
            };

            obj.AddComponent<MockPrefab>();
            PrefabUtility.SaveAsPrefabAsset(obj, MockObjAbsPath);
            
            _factory = new PrefabFactory();
        }

        [Test]
        public void Can_Create_PrefabFactory_Instance_Test()
        {
            // Arrange

            // Act
            var instance = new PrefabFactory();

            // Assertion
        }

        [Test]
        public void Create_Return_Not_Null_Test()
        {
            // Arrange

            // Act
            var sut = _factory.Create<MockPrefab>(MockObjRelPath);

            // Assertion
            Assert.AreNotEqual(sut, null);
        }

        [Test]
        public void Create_Exception_Test1()
        {
            // Arrange

            // Act

            // Assertion
            // 指定した型の例外がテスト対象コードで吐かれたらテスト成功となる
            Assert.Throws<ArgumentException>(() => _factory.Create<MockPrefab>(NeverUsedPrefabPath));
        }

        [Test]
        public void Create_Exception_Test2()
        {
            // Arrange

            // Act

            // Assertion
            // 指定した型の例外がテスト対象コードで吐かれたらテスト成功となる
            Assert.Throws<ArgumentException>(() => _factory.Create<MockPrefab>(NeverUsedPrefabPath));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            AssetDatabase.DeleteAsset(MockObjAbsPath);
        }
    }
}