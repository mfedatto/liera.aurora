using System;
namespace Liera.Aurora.Business.Classifier
{
    public class ClassifierFactory
    {
        public virtual Domain.Classifier.IClassifier CreateClassifier()
        {
            return new Classifier();
        }
    }
}
