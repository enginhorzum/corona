import { Component, OnInit } from "@angular/core";
import { Answer } from "src/app/models/answer.model";
import { Question } from "src/app/models/question.model";
import { RequestService } from "src/app/services/request.service";
import { Observable } from "rxjs";

@Component({
  selector: "app-corona-test-form",
  templateUrl: "./corona-test-form.component.html",
  styleUrls: ["./corona-test-form.component.scss"],
})
export class CoronaTestFormComponent implements OnInit {
  public answerList: Answer[];
  public currentQuestion: Question;
  public isFinalQuestion: boolean;

  public answerListHidden: boolean = true;
  public questionHidden: boolean = true;

  constructor(private requestService: RequestService) {}

  ngOnInit(): void {
    this.reset();
  }

  private getRootQuestion() {
    this.requestService.getRootQuestion().subscribe((data: Question) => {
      this.currentQuestion = data;
      this.isFinalQuestion = this.isFinal(this.currentQuestion);
    });
  }

  private getQuestion(questionId: string) {
    this.requestService.getQuestion(questionId).subscribe((data: Question) => {
      this.currentQuestion = data;
      this.isFinalQuestion = this.isFinal(this.currentQuestion);
      if (this.isFinalQuestion) {
        this.saveAnswers();
      }
    });
  }

  public reset() {
    this.answerList = [];
    this.getRootQuestion();
  }

  public yes() {
    this.saveAnswers(true);
    this.getQuestion(this.currentQuestion.yesQuestionId);
  }

  public no() {
    this.saveAnswers(false);
    this.getQuestion(this.currentQuestion.noQuestionId);
  }

  public isFinal(question: Question) {
    console.log(question.yesQuestionId);
    console.log(question.noQuestionId);
    return question.yesQuestionId == "" && question.noQuestionId == "";
  }

  private saveAnswers(yesOrNo?: boolean): void {
    this.answerList.push({
      question: this.currentQuestion,
      yesOrNo: yesOrNo,
      order: this.answerList.length,
    });
    if (this.isFinalQuestion){
      this.requestService.saveAnswersList(this.answerList).subscribe((data: any) => {
        console.log(data);
      });
    }
  }
}
