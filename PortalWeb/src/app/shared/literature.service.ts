import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LiteratureService {

  readonly rootURL = "https://localhost:44390/api";

  constructor(private http: HttpClient) { }

  getLiterature(){
    return this.http.get(this.rootURL + "/Literature");
  }}
