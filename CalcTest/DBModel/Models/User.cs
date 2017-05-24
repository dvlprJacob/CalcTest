using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Models
{
    public class User
    {
        public User()
        {
            Operations = new List<OperationResult>();
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }

        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        public virtual ICollection<OperationResult> Operations { get; set; }
    }


}
//CREATE TABLE[dbo].[OperationResult] (
//    [Id]
//INT NOT NULL,
//    [OperationName] NCHAR(50)     NOT NULL,
//    [Arguments]     NVARCHAR(MAX) NULL,
//    [Result]        FLOAT(53)     NULL,
//    [ExecutionTime]
//BIGINT NOT NULL,
//    [ExecutionDate]
//DATETIME NOT NULL,
//    [Iniciator]
//BIGINT NOT NULL,
//    PRIMARY KEY CLUSTERED([Id] ASC),
//    CONSTRAINT[FK_dbo.OperationResult_dbo.Users_Iniciator(Id)] FOREIGN KEY([Iniciator]) REFERENCES[dbo].[Users] ([Id])
//);


//GO
//CREATE NONCLUSTERED INDEX[IX_User_Id]
//    ON[dbo].[OperationResult]([Iniciator]
//ASC);



//    CREATE TABLE[dbo].[Users] (
//    [Id]
//BIGINT NOT NULL,
//    [Name]      NVARCHAR(MAX) NULL,
//    [Email]     NVARCHAR(MAX) NULL,
//    [BirthDate]
//DATETIME NOT NULL,
//    [Login]     NVARCHAR(MAX) NULL,
//    [Password]  NVARCHAR(MAX) NULL,
//    PRIMARY KEY CLUSTERED([Id] ASC)
//);
//CREATE TABLE [dbo].[OperationResult] (
//    [Id]            INT           IDENTITY (1, 1) NOT NULL,
//    [OperationName] NVARCHAR (50) NOT NULL,
//    [Arguments]     NVARCHAR (50) NULL,
//    [Result]        FLOAT (53)    NULL,
//    [ExecutionTime] BIGINT        NOT NULL,
//    [ExecutionDate] DATETIME      NOT NULL,
//    [Iniciator_id]  INT           NULL,
//    PRIMARY KEY CLUSTERED ([Id] ASC)
//);