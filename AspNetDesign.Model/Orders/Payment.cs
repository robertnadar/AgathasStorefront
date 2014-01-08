using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetDesign.Infrastructure.Domain;

namespace AspNetDesign.Model.Orders
{
    public class Payment : ValueObjectBase
    {
        private readonly DateTime _datePaid;
        private readonly string _transactionId;
        private readonly string _merchant;
        private readonly decimal _amount;

        public Payment()
        {
        }

        public Payment(DateTime datePaid, string transactionId, string merchant, decimal amount)
        {
            _datePaid = datePaid;
            _transactionId = transactionId;
            _merchant = merchant;
            _amount = amount;
            base.ThrowExceptionIfInvalid();
        }

        public DateTime DatePaid
        {
            get { return _datePaid; }
        }

        public string TransactionId
        {
            get { return _transactionId; }
        }

        public string Merchant
        {
            get { return _merchant; }
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(_transactionId))
                base.AddBrokenRules(PaymentBusinessRules.TransactionIdRequired);
            if (string.IsNullOrEmpty(_merchant))
                base.AddBrokenRules(PaymentBusinessRules.MerchantRequired);
            if (_amount < 0)
                base.AddBrokenRules(PaymentBusinessRules.AmountValid);
        }
    }
}
