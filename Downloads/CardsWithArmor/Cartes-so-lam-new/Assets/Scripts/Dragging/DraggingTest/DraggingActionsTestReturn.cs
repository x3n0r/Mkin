﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DraggingActionsTestReturn : DraggingActionsTest 
{
    private Vector3 savedPos;

    public override void OnStartDrag()
    {
        savedPos = transform.position;
    }

    public override void OnEndDrag()
    {
        //transform.DOMove(savedPos, 0.3f);
        transform.DOMove(savedPos, 0.5f).SetEase(Ease.OutElastic, 0.2f, 0.25f);
        //transform.DOMove(savedPos, 1f).SetEase(Ease.OutQuint);//, 0.5f, 0.1f);
    }

    public override void OnDraggingInUpdate(){}

    protected override bool DragSuccessful()
    {
        return true;
    }
}
