﻿using System;

namespace PHRMS.Services
{
    public interface ITransitionService
    {
        void StartTransition(bool effective);
        void EndTransition(bool effective);
    }

    internal class TransitionService : ITransitionService
    {
        private readonly ISupportTransitions supportTransitions;

        public TransitionService(ISupportTransitions supportTransitions)
        {
            this.supportTransitions = supportTransitions;
        }

        public void StartTransition(bool effective)
        {
            supportTransitions.StartTransition(effective);
        }

        public void EndTransition(bool effective)
        {
            supportTransitions.EndTransition(effective);
        }
    }

    public static class TransitionServiceExtension
    {
        public static IDisposable EnterTransition(this ITransitionService service, bool effective)
        {
            return new TransitionBatch(service, effective);
        }

        private class TransitionBatch : IDisposable
        {
            private readonly bool effective;
            private readonly ITransitionService service;

            public TransitionBatch(ITransitionService service, bool effective)
            {
                this.effective = effective;
                this.service = service;
                service.StartTransition(effective);
            }

            public void Dispose()
            {
                service.EndTransition(effective);
            }
        }
    }
}