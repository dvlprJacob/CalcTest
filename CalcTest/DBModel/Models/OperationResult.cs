using DBModel.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCalc.Managers
{
    [Table("OperationResult")]
    public class OperationResult
    {
        /// <summary>
        /// Результат выполнения операции
        /// </summary>
        public int Id { get; set; }
        public string OperationName { get; set; }
        public string Arguments { get; set; }
        public double? Result { get; set; }
        /// <summary>
        /// Продолжительность выполнения операции
        /// </summary>
        public long ExecutionTime { get; set; }
        public DateTime ExecutionDate { get; set; }
        /// <summary>
        /// Инициатор
        /// </summary>
        public virtual User Iniciator { get; set; }
        
        public long? IniciatorId { get; set; }
    }
}