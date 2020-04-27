import { Injectable } from '@angular/core';
import { AppConfig } from '../models/appconfig.model';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private static settings: AppConfig;

  public static initialize(settings: AppConfig) {
    ConfigService.settings = settings;
  }

  public get settings(): AppConfig {
    return ConfigService.settings;
  }
}
