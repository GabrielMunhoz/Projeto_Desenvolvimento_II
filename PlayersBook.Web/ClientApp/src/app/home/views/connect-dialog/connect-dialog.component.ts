import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IAdvertisement } from 'src/app/models/Advertisements/Iadvertisement';

@Component({
  selector: 'app-connect-dialog',
  templateUrl: './connect-dialog.component.html',
  styleUrls: ['./connect-dialog.component.css']
})
export class ConnectDialogComponent implements OnInit {

  connectForm : FormGroup = this.fb.group({});

  constructor(
    private fb : FormBuilder,
    public dialogRef: MatDialogRef<ConnectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IAdvertisement,
  ) { }

  ngOnInit(): void {
    this.connectForm = this.fb.group({
      TagHostGame : [{value : this.data.tagHostGame, disabled:true}, []],
      LinkDiscord : [{value : this.data.linkDiscord, disabled:true}, []],
    })
  }

  onOkClick(): void {
    this.dialogRef.close();
  }

}
