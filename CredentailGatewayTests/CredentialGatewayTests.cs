// <copyright file="CredentialGatewayTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGatewayTests
{
    using System;
    using CredentialGateway.Logging;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CredentialGatewayTests
    {
        private readonly Mock<ILogger<CredentialGatewayLoggingService>> mockLogger;
        private readonly CredentialGatewayLoggingService credLog;

        public CredentialGatewayTests()
        {
            this.mockLogger = new Mock<ILogger<CredentialGatewayLoggingService>>();
            this.credLog = new CredentialGatewayLoggingService(this.mockLogger.Object);
        }

        [TestMethod]
        public void IssueBegin_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.IssueBegin("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueBegin - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueBegin - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void IssueProgress_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.IssueProgress("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueProgress - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueProgress - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void IssueSuccess_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.IssueSuccess("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueSuccess - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueSuccess - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void IssueFailure_WithParameters_LogError()
        {
            // Act
            var result = this.credLog.IssueFailure("message", "requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueFailure - requestId: requestId, error: message, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void IssueError_WithParameters_LogError()
        {
            // Act
            var result = this.credLog.IssueError("message", "requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("IssueError - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void VerifyBegin_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.VerifyBegin("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyBegin - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyBegin - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void VerifyProgress_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.VerifyProgress("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyProgress - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyProgress - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void VerifySuccess_WithParameters_LogInformationAndLogDebug()
        {
            // Act
            var result = this.credLog.VerifySuccess("requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifySuccess - requestId: requestId")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifySuccess - requestId: requestId, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void VerifyFailure_WithParameters_LogError()
        {
            // Act
            var result = this.credLog.VerifyFailure("message", "requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyFailure - requestId: requestId, error: message, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }

        [TestMethod]
        public void VerifyError_WithParameters_LogError()
        {
            // Act
            var result = this.credLog.VerifyError("message", "requestId", "credentialType", "Issuer");

            // Assert
            this.mockLogger.Verify(
                m => m.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString() !.Contains("VerifyError - requestId: requestId, error: message, credentialType: credentialType, issuer: Issuer.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>() !),
                Times.Once);
        }
    }
}