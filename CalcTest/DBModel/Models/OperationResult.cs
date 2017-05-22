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
        public int Id { get; set; }

        public string OperationName { get; set; }

        public string Arguments { get; set; }

        public double? Result { get; set; }

        public bool NeedUpdate { get; set; }

        /// <summary>
        /// Продолжительность выполнения операции
        /// </summary>
        public long ExecutionTime { get; set; }

        /// <summary>
        /// Дата выполнения операции
        /// </summary>
        public DateTime ExecutionDate { get; set; }

        /// <summary>
        /// Инициатор
        /// </summary>
        public virtual User Iniciator { get; set; }
    }
}