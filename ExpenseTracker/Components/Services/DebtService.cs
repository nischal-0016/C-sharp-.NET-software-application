using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Services
{
    public class DebtService
    {
        private readonly List<Debt> _debts;
        public event Action OnChange;

        public DebtService()
        {
            _debts = new List<Debt>();
        }

        public void AddDebt(Debt debt)
        {
            debt.Id = _debts.Count > 0 ? _debts.Max(d => d.Id) + 1 : 1;

            debt.CreatedAt = DateTime.Now;

            _debts.Add(debt);
            OnChange?.Invoke(); 
        }

        public List<Debt> GetDebts()
        {
            return _debts.OrderByDescending(d => d.CreatedAt).ToList();
        }

        public decimal GetTotalDebt()
        {
            return _debts.Where(d => !d.IsPaid).Sum(d => d.Amount);
        }

        public void PayDebt(int debtId)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == debtId);
            if (debt != null)
            {
                debt.IsPaid = true;
                OnChange?.Invoke();  // Notify subscribers of the change
            }
        }

        public List<Debt> GetOverdueDebts()
        {
            return _debts
                .Where(d => !d.IsPaid && d.DueDate.Date < DateTime.Today)
                .OrderBy(d => d.DueDate)
                .ToList();
        }

        public List<Debt> GetUpcomingDebts(int daysAhead = 7)
        {
            var futureDate = DateTime.Today.AddDays(daysAhead);
            return _debts
                .Where(d => !d.IsPaid &&
                           d.DueDate.Date >= DateTime.Today &&
                           d.DueDate.Date <= futureDate)
                .OrderBy(d => d.DueDate)
                .ToList();
        }

        public decimal GetOverdueAmount()
        {
            return _debts
                .Where(d => !d.IsPaid && d.DueDate.Date < DateTime.Today)
                .Sum(d => d.Amount);
        }

        public void DeleteDebt(int debtId)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == debtId);
            if (debt != null)
            {
                _debts.Remove(debt);
                OnChange?.Invoke();
            }
        }

        public void UpdateDebt(Debt updatedDebt)
        {
            var existingDebt = _debts.FirstOrDefault(d => d.Id == updatedDebt.Id);
            if (existingDebt != null)
            {
                existingDebt.Title = updatedDebt.Title;
                existingDebt.Amount = updatedDebt.Amount;
                existingDebt.Creditor = updatedDebt.Creditor;
                existingDebt.DueDate = updatedDebt.DueDate;
                existingDebt.Notes = updatedDebt.Notes;
                OnChange?.Invoke();
            }
        }
    }
}