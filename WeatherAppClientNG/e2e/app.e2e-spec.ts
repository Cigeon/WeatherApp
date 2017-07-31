import { WeatherAppClientNGPage } from './app.po';

describe('weather-app-client-ng App', () => {
  let page: WeatherAppClientNGPage;

  beforeEach(() => {
    page = new WeatherAppClientNGPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
