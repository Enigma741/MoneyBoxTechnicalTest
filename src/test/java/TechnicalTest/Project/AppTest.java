package TechnicalTest.Project;

import java.io.IOException;

import org.testng.Assert;
import org.testng.annotations.Test;

import PageObjects.AdventurousTab;
import PageObjects.BalancedTabPage;
import PageObjects.CautiousTabPage;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;



public class AppTest extends base {
	@Test
	public void totalValidation() throws IOException, InterruptedException
	{
		AndroidDriver<AndroidElement> driver = capabilities();
		
		// Cautious Tab Page
		CautiousTabPage cautious = new CautiousTabPage(driver);
		cautious.cautioustab.click();
		
		String cashfund1percentage= cautious.cashfund1.getText();
		Assert.assertEquals("85", cashfund1percentage);
		
		String globalsharefund1percentage= cautious.globalsharefund1.getText();
		Assert.assertEquals("10", globalsharefund1percentage);
		
		String propertysharefund1percentage= cautious.propertysharefund1.getText();
		Assert.assertEquals("5", propertysharefund1percentage);
		
		// Balanced Tab Page
		BalancedTabPage balanced = new BalancedTabPage(driver);
		balanced.balancedtab.click();
		
		String cashfund2percentage= balanced.cashfund2.getText();
		Assert.assertEquals("30", cashfund2percentage);
		
		String globalsharefund2percentage= balanced.globalsharefund2.getText();
		Assert.assertEquals("45", globalsharefund2percentage);
		
		String propertysharefund2percentage= balanced.propertysharefund2.getText();
		Assert.assertEquals("25", propertysharefund2percentage);
		
		// Adventurous Tab Page
		AdventurousTab adventurous =new AdventurousTab(driver);
		adventurous.adventuroustab.click();
		
		String cashfund3percentage= adventurous.cashfund3.getText();
		Assert.assertEquals("5", cashfund3percentage);
		
		String globalsharefund3percentage= adventurous.globalsharefund3.getText();
		Assert.assertEquals("60", globalsharefund3percentage);
		
		String propertysharefund3percentage= adventurous.propertysharefund3.getText();
		Assert.assertEquals("35", propertysharefund3percentage);
		
		
	}
	


}
