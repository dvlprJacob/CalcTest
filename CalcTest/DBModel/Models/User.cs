using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            OperationResults = new List<OperationResult>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<OperationResult> OperationResults { get; set; }
    }
}
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