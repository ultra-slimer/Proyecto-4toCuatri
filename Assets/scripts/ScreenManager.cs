using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    Stack<IScreen> _stacks = new Stack<IScreen>();

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pop();
    }

    public void Push(IScreen screen)
    {
        if (_stacks.Count > 0)
            _stacks.Peek().Trasparent();

        _stacks.Push(screen);
        screen.Activate();
    }

    public void Pop()
    {
        if (_stacks.Count <= 0)
            return;

        _stacks.Pop().Desactivate();

        if (_stacks.Count > 0)
            _stacks.Peek().Activate();
    }

    public void CloseAll()
    {
        print(_stacks.Count);
        for(int i = 0; i < _stacks.Count; i++)
        {
            _stacks.Pop().Desactivate();
        }
    }
}
