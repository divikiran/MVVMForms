
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MVVMForms
{
    public abstract class ExtendedBindableObject : BindableObject
    {
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.OnPropertyChanged(propertyName);
        }

        //public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        //{
        //    var name = GetMemberInfo(property).Name;
        //    OnPropertyChanged(name);
        //}

        //private MemberInfo GetMemberInfo(Expression expression)
        //{
        //    MemberExpression operand;
        //    LambdaExpression lambdaExpression = (LambdaExpression)expression;
        //    if (lambdaExpression.Body as UnaryExpression != null)
        //    {
        //        UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
        //        operand = (MemberExpression)body.Operand;
        //    }
        //    else
        //    {
        //        operand = (MemberExpression)lambdaExpression.Body;
        //    }
        //    return operand.Member;
        //}
    }
}