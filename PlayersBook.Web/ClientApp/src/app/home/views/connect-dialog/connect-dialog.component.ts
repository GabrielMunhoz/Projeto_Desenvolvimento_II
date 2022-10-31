import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IAdvertisement } from 'src/app/models/Advertisements/Iadvertisement';
import { faClipboard, faClipboardCheck} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-connect-dialog',
  templateUrl: './connect-dialog.component.html',
  styleUrls: ['./connect-dialog.component.css']
})
export class ConnectDialogComponent implements OnInit {
  iconClipboardTag = faClipboard;
  iconClipboardLink = faClipboard;
  
  connectForm : UntypedFormGroup = this.fb.group({});

  constructor(
    private fb : UntypedFormBuilder,
    public dialogRef: MatDialogRef<ConnectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IAdvertisement,
  ) { }

  ngOnInit(): void {
    this.connectForm = this.fb.group({
      TagHostGame : [{value : this.data.tagHostGame, disabled:true}, []],
      LinkDiscord : [{value : this.data.linkDiscord, disabled:true}, []],
    })
  }

  changeIconTag(){
    this.iconClipboardTag = faClipboardCheck;
  }
  changeIconLink(){
    this.iconClipboardLink = faClipboardCheck;
  }

  onOkClick(): void {
    this.dialogRef.close();
  }

}
