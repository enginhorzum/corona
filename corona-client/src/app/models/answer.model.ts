import { Question } from './question.model';

export interface Answer {
  question: Question;
  yesOrNo?: boolean;
  order: number;
}
