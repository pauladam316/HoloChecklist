public interface IApplicationState
{
	/**
	 * Begin
	 * Initialization for the state
	 */
	void Begin();

	/**
	 * Update
	 * Updates the state
	 */
	void Update();

	/**
	 * Begin
	 * Stops the state
	 */
	void Stop();
}