﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using portal_project.Models;
using portal_project.Service;
using System;
using System.Collections.Generic;
using TestUnitaire.Mock;

namespace TestUnitaire
{
    [TestClass]
    public class PhotoTest
    {
        PhotoMockDao dao;
        PhotoService service;
        [TestInitialize]
        public void Setup()
        {
            dao = new PhotoMockDao();
            service = new PhotoService(dao);
            User user = new User
            {
                Id = 1
            };
            Photo photo = new Photo
            {
                Id = 1,
                DateUpload = new DateTime(2021, 12, 4),
                PhotoTitle = "CDM",
                UserUploader = user
            };
            dao.Photos.Add(photo);
        }

        [TestCleanup]
        public void Clean()
        {
            dao.Photos.Clear();
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Create")]
        public void CreatePhoto_DifferentId_Return_Count_Equals2()
        {
           Photo photo = new Photo()
            {
                Id = 2,
                PhotoTitle="CDM2022"
            };
            service.createPhoto(photo);
            Assert.AreEqual(2, dao.Photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Create")]
        public void CreatePhoto_SameId_Return_Count_Equals1()
        {
            Photo photo = new Photo()
            {
                Id = 1,
                PhotoTitle = "CDM2022"
            };
            service.createPhoto(photo);
            Assert.AreEqual(1, dao.Photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Delete")]
        public void DeletePhoto_DifferentId_Return_Count_Equals0()
        {
            service.deletePhoto(1);
            Assert.AreEqual(0, dao.Photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Delete")]
        public void DeletePhoto_DifferentId_Return_Count_Equals1()
        {
            service.deletePhoto(2);
            Assert.AreEqual(1, dao.Photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Edit")]
        public void EditPhoto_KnownId_Return_Item_Edited()
        {
            Photo photo = new Photo
            {
                Id = 1,
                PhotoTitle = "CDM2022"
            };
            service.editPhoto(photo);
            Assert.AreEqual(photo.PhotoTitle, service.findOneById(1).PhotoTitle);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "Edit")]
        public void EditPhoto_UnknownId_Return_Item_NotEdited()
        {
            Photo photo = new Photo
            {
                Id = 2,
                PhotoTitle = "CDM2022"
            };
            service.editPhoto(photo);
            Assert.AreEqual("CDM", service.findOneById(1).PhotoTitle);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindByDateUpload")]
        public void FindByDateUploadPhoto_KnownDate_Return_Count_Equals1()
        {
            DateTime dateTime = new DateTime(2021,12,4,16,50,15);
            List<Photo> photos = service.findByDateUpload(dateTime);
            Assert.AreEqual(1, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindByDateUpload")]
        public void FindByDateUploadPhoto_UnknownDate_Return_Count_Equals0()
        {
            DateTime dateTime = new DateTime(2021, 12, 5, 16, 50, 15);
            List<Photo> photos = service.findByDateUpload(dateTime);
            Assert.AreEqual(0, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindByTitle")]
        public void FindByTitlePhoto_KnownTitle_Return_Count_Equals1()
        {
            List<Photo> photos = service.findByTitle("CDM");
            Assert.AreEqual(1, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindByTitle")]
        public void FindByTitlePhoto_UnknownTitle_Return_Count_Equals0()
        {
            List<Photo> photos = service.findByTitle("CDM2");
            Assert.AreEqual(0, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindOneById")]
        public void FindByIdPhoto_KnownId_Return_Count_Equals1()
        {
            Photo photo = service.findOneById(1);
            Assert.AreEqual("CDM", photo.PhotoTitle);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "FindOneById")]
        public void FindByIdPhoto_UnknownId_Return_Count_Equals0()
        {
            Photo photo = service.findOneById(2);
            Assert.AreEqual(null, photo);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "GetAllPhoto")]
        public void GetAllPhoto_Return_Count_Equals1()
        {
            List<Photo> photos = service.getAllPhotos();
            Assert.AreEqual(1, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "GetAllUserPhoto")]
        public void GetAllUserPhoto_IdUserHavePhoto_Return_Count_Equals1()
        {
            List<Photo> photos = service.getAllUserPhoto(new User { Id = 1 });
            Assert.AreEqual(1, photos.Count);
        }

        [TestMethod]
        [TestCategory("Photo")]
        [TestProperty("Test Photo", "GetAllUserPhoto")]
        public void GetAllUserPhoto_IdUserDontHavePhoto_Return_Count_Equals0()
        {
            List<Photo> photos = service.getAllUserPhoto(new User { Id = 2 });
            Assert.AreEqual(0, photos.Count);
        }
    }
}
