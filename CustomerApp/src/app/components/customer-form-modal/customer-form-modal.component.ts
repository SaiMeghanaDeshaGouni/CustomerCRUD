import { Component, EventEmitter, Output, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/Customer';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-customer-form-modal',
  templateUrl: './customer-form-modal.component.html',
  styleUrls: ['./customer-form-modal.component.css']
})
export class CustomerFormModalComponent {
  customerForm: FormGroup;
  @Output() addOrUpdateCustomer = new EventEmitter<any>();
  btnLabel: String = 'Add';
  submitted = false;

  constructor(private fb: FormBuilder, @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<CustomerFormModalComponent>) {
    this.customerForm = this.fb.group({
      id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      created: [''],
      lastUpdated: ['']
    });

    if (this.data != null) {
      this.customerForm.patchValue(this.data.customerToEdit);
      this.btnLabel = 'Edit';
    }
    else {
      this.btnLabel = 'Add';
    }
  }

  onSubmit() {
    this.submitted = true;
    if (this.customerForm.valid) {
      const newCustomer = {
        ...this.customerForm.value,
        created: new Date(),
        lastUpdated: new Date()
      };
      this.addOrUpdateCustomer.emit(newCustomer);
      this.customerForm.reset();
    }
  }

  get customerFormControl() {
    return this.customerForm.controls;
  }

  closeModal() {
    this.dialogRef.close();
  }
}
