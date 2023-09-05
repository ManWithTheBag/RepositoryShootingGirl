using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FancyCell<TItemData, TContext> : MonoBehaviour where TContext : class, new()
{
    public int Index { get; set; } = -1;
    public virtual bool IsVisible => gameObject.activeSelf;
    protected TContext Context { get; private set; }
    public virtual void SetContext(TContext context) => Context = context;
    public virtual void Initialize() { }
    public virtual void SetVisible(bool visible) => gameObject.SetActive(visible);
    public abstract void UpdateContent(TItemData itemData);
    public abstract void UpdatePosition(float position);
}

public abstract class FancyCell<TItemData> : FancyCell<TItemData, NullContext>
{
    /// <inheritdoc/>
    public sealed override void SetContext(NullContext context) => base.SetContext(context);
}
