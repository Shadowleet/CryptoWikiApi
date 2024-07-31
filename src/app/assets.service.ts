import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AssetsService {
  private url = 'https://localhost:7078/api/Assets'; // URL to the JSON server for assets

  constructor(private http: HttpClient) {}

  // Fetch the list of assets
  getAssets(): Observable<any[]> {
    return this.http.get<any[]>(this.url);
  }

  // Fetch a single asset by id
  getAsset(id: string): Observable<any> {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  // Add a new asset
  addAsset(asset: any): Observable<any> {
    return this.http.post<any>(this.url, asset);
  }

  // Update an existing asset
  updateAsset(asset: any): Observable<any> {
    return this.http.put<any>(`${this.url}/${asset.id}`, asset);
  }

  // Delete an asset by id
  deleteAsset(id: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}