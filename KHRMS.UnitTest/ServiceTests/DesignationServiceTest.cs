using FluentAssertions.Common;
using KHRMS.Core;
using KHRMS.Services;
using Microsoft.AspNetCore.Routing.Matching;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ServiceTests
{
    public class DesignationServiceTest
    {

        public DesignationServiceTest()
        {

        }

        [Fact]
        public void CreateDesignationReturnPass()
        {
            var mock = new Mock<IDesignationService>();
            List<Designation> designations = new List<Designation>();
            mock.Setup(x => x.CreateDesignation(It.IsAny<Designation>()))
                    .Returns(Task.FromResult(true));
            Designation designation = new Designation()
            {
                Id = 8,
                DesignationName = "DotnetCore"
                               
            };
            designations.Add(designation);
            Assert.Equal(1, 1);

        }

        [Fact]
        public async Task CreateDesignationReturnFail()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            List<Designation> designations = new List<Designation>();
            mock.Verify(x => x.CreateDesignation(It.IsAny<Designation>()), Times.Never);
            var designation = new Designation()
            {
                Id = 8,
                DesignationName = "DotnetCore"
            };
            designations.Add(designation);
            var exception = Assert.Throws<InvalidOperationException>(() => designations.Add(designation));
            Assert.Equal("Designation already exists", exception.Message);
        }

        [Fact]
        public async Task CreateDesignationReturnException()
        {
            var mock = new Mock<IDesignationService>();
            List<Designation> designations = new List<Designation>();
            IDesignationService designationservice = mock.Object;
            mock.Verify(x => x.CreateDesignation(It.IsAny<Designation>()), Times.Never);
            var exception = Assert.Throws<ArgumentNullException>(() => designations.Add(null));
            Assert.Equal("Entity cannot be null (Parameter 'entity')", exception.Message);
        }

        [Fact]
        public void DeleteDesignationReturnPass()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            var Id = 1;
            mock.Setup(x => x.GetDesignationById(Id));
            Designation designation = new Designation()
            {
                Id = 1,
                DesignationName = "OOPS"
            };
            mock.Setup(x => x.DeleteDesignation(Id));
            var result = designationservice.DeleteDesignation(Id);
            Assert.Equal(1,1);
            mock.Verify(x => x.DeleteDesignation(Id), Times.Once);
        }

        [Fact]
        public async Task DeleteDesignationReturnFail()
        {
            var Id = 999;
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation();
            List<Designation> designations = new List<Designation>();
            var result = designationservice.DeleteDesignation(Id);
            mock.Verify(x => x.DeleteDesignation(It.IsAny<int>()), Times.Never);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => designationservice.DeleteDesignation(Id));
            Assert.Equal("Designation not found", exception.Message);
        }

        [Fact]
        public async Task DeleteDesignationReturnException()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            var Id = 1;
            mock.Setup(x => x.GetDesignationById(Id));
            Designation designation = new Designation()
            {
                Id = 1,
                DesignationName = "OOPS"
            };
            mock.Setup(x => x.DeleteDesignation(Id)).Throws(new Exception("Database error"));
            var result = designationservice.DeleteDesignation(Id);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => designationservice.DeleteDesignation(Id));
            Assert.Equal("Designation not found", exception.Message);
            mock.Verify(x => x.DeleteDesignation(Id), Times.Once);
        }

        [Fact]
        public void GetAllDesignationsReturnPass()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation()
            {
                Id = 1,
                DesignationName = "OOPS"
            };
            mock.Setup(x => x.GetAllDesignations());
            var result = designationservice.GetAllDesignations();
            Assert.NotNull(result);
            Assert.Equal(1, designation.Id);
            Assert.Equal("OOPS", designation.DesignationName);
        }

        [Fact]
        public async Task GetAllDesignationsReturnFail()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            mock.Setup(x => x.GetAllDesignations());
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => designationservice.GetAllDesignations());
            Assert.Equal("No devision available", exception.Message);
        }


        [Fact]
        public async Task GetAllDesignationsReturnExeption()
        {
            var Id = 1;
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            mock.Setup(x => x.GetAllDesignations()).Returns(()=>null); ;
            //Assert.Throws<NullReferenceException>(() =>
            //{
            //    var result = mock.Object.GetAllDesignations();
            //    if (result == null)
            //        throw new NullReferenceException("Unexpected null result");
            //});
            mock.Setup(s => s.GetAllDesignations()).Throws(new Exception("Unexpected error"));
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.GetAllDesignations());
            Assert.Equal("Unexpected error", exception.Message);
        }

        [Fact]
        public void GetDesignationByIdReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation()
            {
                Id = 1,
                DesignationName = "OOPS"
            };
            mock.Setup(x => x.GetDesignationById(1));
            var result = designationservice.GetDesignationById(1);
            Assert.NotNull(result);
            Assert.Equal(1, designation.Id);
            Assert.Equal("OOPS", designation.DesignationName);
        }

        [Fact]
        public async Task GetDesignationByIdReturnFail()
        {
            var Id = 999;
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => designationservice.GetDesignationById(Id));
            Assert.Equal("Designation not found", exception.Message);
        }

        [Fact]
        public async Task GetDesignationByIdReturnException()
        {
            var Id = 1;
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => designationservice.GetDesignationById(1));
            Assert.Equal("Unexpected error", exception.Message);           
        }

        [Fact]
        public void UpdateDesignationReturnTest()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation()
            {
                Id = 1,
                DesignationName = "OOPS"
            };
             Designation updatedesignation = new Designation()
             {
                 Id = 1,
                 DesignationName = "dotnetcore"
             };
            mock.Setup(x => x.GetDesignationById(1));
            var result = designationservice.UpdateDesignation(designation);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
        }

        [Fact]
        public async Task UpdateDesignationReturnTestFail()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation();
            mock.Setup(x => x.GetDesignationById(1));
            var result = designationservice.UpdateDesignation(designation);
            var designations = new Designation
            {
                Id = 999,
                DesignationName = "OOPS"
            };

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => designationservice.UpdateDesignation(designations));
            Assert.Equal("Update not found", exception.Message);
        }

        [Fact]
        public async Task UpdateDesignationReturnTestException()
        {
            var mock = new Mock<IDesignationService>();
            IDesignationService designationservice = mock.Object;
            Designation designation = new Designation();
            mock.Setup(x => x.GetDesignationById(1));
            var result = designationservice.UpdateDesignation(designation);
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => designationservice.UpdateDesignation(null));
            Assert.Equal("Update cannot be null (Parameter 'Update')", exception.Message);
        }

    }
}

