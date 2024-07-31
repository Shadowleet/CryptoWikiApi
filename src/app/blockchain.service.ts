import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Blockchain } from './blockchain.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlockchainService {

  private apiUrl = 'https://localhost:7078/api/Blockchains'
  constructor(private http: HttpClient) { }

  getAllBlockchains(): Observable<Blockchain[]> {
    return this.http.get<Blockchain[]>(this.apiUrl);
  }

  getBlockchain(id: number): Observable<Blockchain> {
    return this.http.get<Blockchain>(`${this.apiUrl}/${id}`);
  }

  addBlockchain(blockchain: Blockchain): Observable<Blockchain> {
    return this.http.post<Blockchain>(this.apiUrl, blockchain);
  }

  updateBlockchain(blockchain: Blockchain): Observable<Blockchain> {
    return this.http.put<Blockchain>(`${this.apiUrl}/${blockchain.blockchainId}`, blockchain);
  }

  deleteBlockchain(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}