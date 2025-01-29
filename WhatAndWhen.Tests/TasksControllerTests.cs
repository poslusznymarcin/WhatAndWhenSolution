using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatAndWhen.Data;
using WhatAndWhen.Web.Controllers;


namespace WhatAndWhen.Tests
{
    [TestFixture]
    public class TasksControllerTests : IDisposable
    {
        private TasksController _controller;
        private WhatAndWhenContext _context;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WhatAndWhenContext>()
                .UseInMemoryDatabase(databaseName: "WhatAndWhenTestDb")
                .Options;

            _context = new WhatAndWhenContext(options);
            _context.Tasks.Add(new Data.Entities.Task { Title = "TestTask", Id = 1 });
            _context.SaveChanges();
            _controller = new TasksController(_context);
        }

        [Test]
        public async Task Index_ReturnsViewResult_WithList()
        {
            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result.ViewName, Is.EqualTo("Index").Or.Null);
            Assert.That(result.Model, Is.Not.Null);
            var model = result.Model as List<Data.Entities.Task>;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
            if (_controller != null)
            {

            }
        }

        public void Dispose()
        {
            
            _context?.Dispose();
            _controller = null;
        }
    }
}