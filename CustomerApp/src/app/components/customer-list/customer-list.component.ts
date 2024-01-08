import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { StorageService } from 'src/app/services/storage.service';
import { Customer } from '../../models/Customer';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { CustomerFormModalComponent } from '../customer-form-modal/customer-form-modal.component';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent {

  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'created', 'lastUpdated', 'actions'];

  selectedCustomerId: number | null = null;
  customerToEdit: Customer | null = null;
  customers!: MatTableDataSource<Customer>;
  @ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(new MatPaginatorIntl(), ChangeDetectorRef.prototype);
  @ViewChild(MatSort) sort: MatSort = new MatSort();



  constructor(private customerService: CustomerService,
    private storageService: StorageService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadCustomers();
    this.loadSelectedCustomerId();
  }

  ngAfterViewInit() {
    this.customers.sort = this.sort;
    this.customers.paginator = this.paginator;
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = new MatTableDataSource(customers);
      this.customers.sort = this.sort;
      this.customers.paginator = this.paginator;
    });
  }

  loadSelectedCustomerId(): void {
    this.selectedCustomerId = this.storageService.getItem('selectedCustomerId');
  }

  selectCustomer(customer: Customer): void {
    this.selectedCustomerId = customer.id;
    this.storageService.setItem('selectedCustomerId', customer.id);
  }

  isCustomerSelected(customer: Customer): boolean {
    return this.selectedCustomerId === customer.id;
  }

  updateCustomerList(updatedCustomer: Customer): void {
    const index = this.customers.data.findIndex((c: { id: number; }) => c.id === updatedCustomer.id);
    if (index !== -1) {
      const updatedCustomers = [...this.customers.data];
      updatedCustomers[index] = updatedCustomer;
      this.customers.data = updatedCustomers;
    }
  }

  openAddOrEditCustomerModal(customer: Customer | null): void {
    const isEdit = customer != null ? true : false;

    if (isEdit) {

      this.selectedCustomerId = customer!.id;
      this.storageService.setItem('selectedCustomerId', customer!.id);
      const dialogRef = this.dialog.open(CustomerFormModalComponent, {
        width: '400px',
        data: { customerToEdit: customer }
      });
      dialogRef.componentInstance.addOrUpdateCustomer.subscribe((updatedCustomer: Customer) => {
        if (customer) {
          // Editing an existing customer          
          this.customerService.updateCustomer(updatedCustomer).subscribe(() => {
            this.updateCustomerList(updatedCustomer);
            dialogRef.close();
          });
        }
      })
    }
    else {
      const dialogRef = this.dialog.open(CustomerFormModalComponent, {
        width: '400px',
      });
      // Adding new customer
      dialogRef.componentInstance.addOrUpdateCustomer.subscribe((newCustomer: Customer) => {
        newCustomer.id = 0;
        this.customerService.addCustomer(newCustomer).subscribe(addedCustomer => {
          const updatedCustomers = this.customers.data.concat(addedCustomer);
          this.customers.data = updatedCustomers;
          dialogRef.close();
        });
      });

    }
  }
}
