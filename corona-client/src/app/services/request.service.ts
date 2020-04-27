import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { Answer } from '../models/answer.model';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { Question } from '../models/question.model';

@Injectable({
  providedIn: 'root',
})
export class RequestService {
  private apiUrl: string;
  constructor(private httpClient: HttpClient, config: ConfigService) {
    this.apiUrl = environment.apiUrl;
  }

  public getRootQuestion(): Observable<Question> {
    return this.httpClient.get<Question>(`${this.apiUrl}question/root`);
  }

  public getQuestion(questionId: string): Observable<Question> {
    return this.httpClient.get<Question>(`${this.apiUrl}question/${questionId}`);
  }

  public saveAnswersList(answersList: Answer[]): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}answer/save`, answersList);
  }
}
