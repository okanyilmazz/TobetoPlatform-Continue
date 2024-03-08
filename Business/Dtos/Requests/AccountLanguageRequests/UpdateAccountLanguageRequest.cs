﻿namespace Business.Dtos.Requests.AccountLanguageRequests
{
    public class UpdateAccountLanguageRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
    }
}