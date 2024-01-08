import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of, tap } from 'rxjs';
import { Customer } from '../models/Customer'

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrl = 'http://localhost:5013/api/customers/';
  private customers: Customer[] = [];

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      tap((data) => {
        this.customers = data;
      }),
      catchError(this.handleError('getCustomers', []))
    );
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl + "CreateCustomer", customer);
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    let updateURL = `${this.apiUrl + "UpdateCustomer"}/${customer.id}`;
    return this.http.post<any>(updateURL, customer);
  }

  private getNextId(): number {
    const maxId = Math.max(...this.customers.map(c => c.id), 0);
    return maxId + 1;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
}
