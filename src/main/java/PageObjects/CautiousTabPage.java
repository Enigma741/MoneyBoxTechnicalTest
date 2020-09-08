package PageObjects;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;

public class CautiousTabPage {
	public CautiousTabPage(AndroidDriver<AndroidElement> driver)
	{
		PageFactory.initElements(new AppiumFieldDecorator(driver), this);
	}
	
	@AndroidFindBy(xpath="//*[@Text='Cautious']")
	public WebElement cautioustab;
	
	@AndroidFindBy(xpath="//*[@Text='85']")
	public WebElement cashfund1;
	
	@AndroidFindBy(xpath="//*[@Text='10']")
	public WebElement globalsharefund1;
	
	@AndroidFindBy(xpath="//*[@Text='5']")
	public WebElement propertysharefund1;
	
	public WebElement cautioustabfield()
	{
		return cautioustab;
	}
	
	public WebElement cashfund1field()
	{
		return cashfund1;
	}
	public WebElement globalsharefund1field()
	{
		return globalsharefund1;
	}
	public WebElement propertysharefund1field()
	{
		return propertysharefund1;
	}
	
	

}
