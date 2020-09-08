package PageObjects;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;

public class AdventurousTab {
	
	public AdventurousTab(AndroidDriver<AndroidElement> driver)
	{
		PageFactory.initElements(new AppiumFieldDecorator(driver), this);
	}

	@AndroidFindBy(xpath="//*[@Text='Adventurous']")
	public WebElement adventuroustab;
	
	@AndroidFindBy(xpath="//*[@Text='5']")
	public WebElement cashfund3;
	
	@AndroidFindBy(xpath="//*[@Text='60']")
	public WebElement globalsharefund3;
	
	@AndroidFindBy(xpath="//*[@Text='35']")
	public WebElement propertysharefund3;
	
	public WebElement adventuroustabfield()
	{
		return adventuroustab;
	}
	
	public WebElement cashfund3field()
	{
		return cashfund3;
	}
	public WebElement globalsharefund3field()
	{
		return globalsharefund3;
	}
	public WebElement propertysharefund3field()
	{
		return propertysharefund3;
	}

}
