import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-advertisement-dialog',
  templateUrl: './create-advertisement-dialog.component.html',
  styleUrls: ['./create-advertisement-dialog.component.css']
})
export class CreateAdvertisementDialogComponent implements OnInit {

  public advertisementForm: FormGroup = this.fb.group({}); 

  public playersName = ["gabriel", "rafa"]

  constructor(
    private fb : FormBuilder,
    public dialogRef: MatDialogRef<CreateAdvertisementDialogComponent>
    ) { }

  ngOnInit(): void {
    this.advertisementForm = this.fb.group({
      GameCategory : ['', [Validators.required]],
      GroupCategory : ['', [Validators.required]],
      IsActive : [true, [Validators.required]],
      PlayerHostId : ['', [Validators.required]],
      PlayerHostName : ['', [Validators.required]],
    })
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }
}
