using System;
using OpenRailData.TrainDescriberStorage.EntityFramework.Repository;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork
{
    public class TrainDescriberUnitOfWork : ITrainDescriberUnitOfWork
    {
        private readonly ITrainDescriberContext _context;

        public TrainDescriberUnitOfWork(ITrainDescriberContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

            BerthMessages = new BerthMessageRepository(_context);
            SignalMessages = new SignalMessageRepository(_context);
        }

        public void Dispose() => _context?.Dispose();

        public IBerthMessageRepository BerthMessages { get; }
        public ISignalMessageRepository SignalMessages { get; }

        public int Complete() => _context.SaveChanges();
    }
}