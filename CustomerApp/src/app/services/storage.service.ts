import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  getItem(key: string): number | null {
    return JSON.parse(sessionStorage.getItem(key) || "")
  }

  setItem(key: string, id: number): void {
    sessionStorage.setItem(key, id.toString());
  }
}
