using DBModel.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModel.Models
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    [Table("OperationResult")]
    public class OperationResult
    {
        public virtual int Id { get; set; }

        public virtual string OperationName { get; set; }

        public virtual string Arguments { get; set; }

        public virtual double? Result { get; set; }

        public virtual bool NeedUpdate { get; set; }

        /// <summary>
        /// Продолжительность выполнения операции
        /// </summary>
        public virtual long ExecutionTime { get; set; }

        /// <summary>
        /// Дата выполнения операции
        /// </summary>
        public virtual DateTime ExecutionDate { get; set; }

        /// <summary>
        /// Инициатор
        /// </summary>
        public virtual User Iniciator { get; set; }
    }
}