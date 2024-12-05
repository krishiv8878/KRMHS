using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions.Common;
using KHRMS.Controllers;
using KHRMS.Core;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Moq;
using NPOI.SS.Formula.Functions;
using System.Linq;
using System.Xml.Linq;

namespace KHRMS.UnitTest
{
    public class AssetMasterServiceTest
    {
        public AssetMasterServiceTest()
        {

        }

        [Fact]
        public void AddAssetsReturnPass()
        {
            var mock = new Mock<IAssetsMasterService>();
            mock.Setup(x => x.AddAssetsMaster(It.IsAny<AssetsMaster>()))
                      .Returns(Task.FromResult(true));
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            AssetsMaster assetsMaster = new AssetsMaster()
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            assetsMasters.Add(assetsMaster);
            Assert.Equal(1, 1);
        }

        [Fact]
        public void AddAssetsReturnFail()
        {
            var mock = new Mock<IAssetsMasterService>();
            mock.Setup(x => x.AddAssetsMaster(It.IsAny<AssetsMaster>()))
                      .Returns(Task.FromResult(true));
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            AssetsMaster assetsMaster = new AssetsMaster()
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            assetsMasters.Add(assetsMaster);
            Assert.Equal(1, 1);
            var exception = Assert.Throws<InvalidOperationException>(() => assetsMasters.Add(assetsMaster));
            Assert.Equal("Assets already exists", exception.Message);
        }

        [Fact]
        public void AddAssetsReturnException()
        {
            var mock = new Mock<IAssetsMasterService>();
            mock.Setup(x => x.AddAssetsMaster(It.IsAny<AssetsMaster>()))
                      .Returns(Task.FromResult(true));
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            AssetsMaster assetsMaster = new AssetsMaster();
            assetsMasters.Add(assetsMaster);
            var exception = Assert.Throws<ArgumentNullException>(() => assetsMasters.Add(null));
            Assert.Equal("Assets cannot be null (Add 'entity')", exception.Message);
        }

        [Fact]
        public void DeletedAssetsMasterReturnsPass()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.DeleteAssetsMaster(1));
            var result = assetsservice.DeleteAssetsMaster(Id);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            mock.Verify(x => x.DeleteAssetsMaster(1), Times.Once);
        }

        [Fact]
        public async Task DeletedAssetsMasterReturnsFail()
        {
            var Id = 999;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.DeleteAssetsMaster(1));
            var result = assetsservice.DeleteAssetsMaster(Id);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.DeleteAssetsMaster(Id));
            Assert.Equal("Assert not found", exception.Message);
        }

        [Fact]
        public async Task DeletedAssetsMasterReturnsException()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.DeleteAssetsMaster(1));
            var result = assetsservice.DeleteAssetsMaster(Id);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.DeleteAssetsMaster(Id));
            Assert.Equal("Designation not found", exception.Message);
           mock.Verify(x=>x.DeleteAssetsMaster(1),Times.Once);
        }

        [Fact]
        public void GetAllAssetsMasterReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.GetAllAssetsMaster());
            var result = assetsservice.GetAllAssetsMaster();
            Assert.NotNull(result);
            Assert.Equal(1, assetdata.Id);
            Assert.Equal("Java", assetdata.AssetsMasterName);
        }


        [Fact]
        public async Task GetAllAssetsMasterReturnFail()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            mock.Setup(x => x.GetAllAssetsMaster());
            var result = assetsservice.GetAllAssetsMaster();
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => assetsservice.GetAllAssetsMaster());
            Assert.Equal("No assets available", exception.Message);
        }

        [Fact]
        public async Task GetAllAssetsMasterReturnException()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var result = assetsservice.GetAllAssetsMaster();
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.GetAllAssetsMaster());
            Assert.Equal("Unexpected error", exception.Message);
        }
        
        [Fact]
        public void GetAssetsMasterByIdReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.GetAssetsMasterById(1);
            Assert.NotNull(result);
            Assert.Equal(1, assetdata.Id);
            Assert.Equal("Java", assetdata.AssetsMasterName);
        }

        [Fact]
        public async Task GetAssetsMasterByIdReturnFail()
        {
            var Id = 999;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.GetAssetsMasterById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.GetAssetsMasterById(Id));
            Assert.Equal("Assert not found", exception.Message);
        }

        [Fact]
        public async Task GetAssetsMasterByIdReturnException()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.GetAssetsMasterById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.GetAssetsMasterById(1));
            Assert.Equal("Assert not found", exception.Message);
        }

        [Fact]
        public void UpdateAssetsMastereReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            var updateassetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "C#",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.UpdateAssetsMaster(assetdata);
            Assert.NotNull(result);
            Assert.Equal(1, assetdata.Id);
            Assert.Equal("Java", assetdata.AssetsMasterName);
        }

        [Fact]
        public async Task UpdateAssetsMastereReturnFail()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.UpdateAssetsMaster(assetdata);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.UpdateAssetsMaster(assetdata));
            Assert.Equal("Update not found", exception.Message);
        }

        [Fact]
        public async Task UpdateAssetsMastereReturnException()
        {
            var Id = 1;
            var mock = new Mock<IAssetsMasterService>();
            IAssetsMasterService assetsservice = mock.Object;
            List<AssetsMaster> assetsMasters = new List<AssetsMaster>();
            var assetdata = new AssetsMaster
            {
                Id = 1,
                AssetsMasterName = "Java",
                Description = new DateTime(2024, 11, 26, 12, 0, 0),
                SerialNumber = "string",
                DateOfPurchase = new DateTime(2024, 11, 26, 12, 0, 0)
            };
            mock.Setup(x => x.GetAssetsMasterById(1));
            var result = assetsservice.UpdateAssetsMaster(assetdata);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => assetsservice.UpdateAssetsMaster(null));
            Assert.Equal("Update not found", exception.Message);
        }
    }
}
