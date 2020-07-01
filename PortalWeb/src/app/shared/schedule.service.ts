import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Schedule } from './message-detail.model';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  readonly rootURL = "https://localhost:44390/api";

  constructor(private http: HttpClient) { }

  getSchedule(){
    return this.http.get(this.rootURL + "/Meeting");
  }

  deleteSchedule(id){
    return this.http.delete(this.rootURL + "/Meeting/DeleteLink", id);
  }
}
